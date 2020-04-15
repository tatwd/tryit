#include <stdio.h>
#include <assert.h>
#include <uv.h>

#define BUF_MAX 1024

void on_open(uv_fs_t *req);
void on_read(uv_fs_t *req);
void on_write(uv_fs_t *req);

char buffer[BUF_MAX];
uv_buf_t iov;
uv_fs_t open_req;
uv_fs_t read_req;
uv_fs_t write_req;

void on_open(uv_fs_t *req)
{
	assert(req == &open_req);
	if (req->result >= 0) {
		// 成功打开文件则开始读取数据
		iov = uv_buf_init(buffer, sizeof(buffer));
		uv_fs_read(uv_default_loop(), &read_req, req->result,
		           &iov, 1, -1, on_read);
	} else {
		fprintf(stderr, "error opening file: %s\n", uv_strerror((int)req->result));
	}
}

void on_read(uv_fs_t *req)
{
	if (req->result < 0) {
		fprintf(stderr, "read error: %s\n", uv_strerror(req->result));
	} else if (req->result == 0) {
		uv_fs_t close_req;
		/* synchronous */
		uv_fs_close(uv_default_loop(), &close_req, open_req.result, NULL);
	} else if (req->result > 0) {
		iov.len = req->result;
		uv_fs_write(uv_default_loop(), &write_req, 1, &iov, 1, -1, on_write);
	}
}

void on_write(uv_fs_t *req)
{
	if (req->result < 0) {
		fprintf(stderr, "write error: %s\n", uv_strerror((int)req->result));
	} else {
		uv_fs_read(uv_default_loop(), &read_req, open_req.result,
		           &iov, 1, -1, on_read);
	}
}

int main(int argc, char **argv)
{
	uv_fs_open(uv_default_loop(), &open_req, argv[1], O_RDONLY, 0, on_open);
	uv_run(uv_default_loop(), UV_RUN_DEFAULT);

	/* must call uv_fs_re_cleanup in fs req */
	uv_fs_req_cleanup(&open_req);
	uv_fs_req_cleanup(&read_req);
	uv_fs_req_cleanup(&write_req);
	return 0;
}
