SRCS := a.c b.c c.c

# T1_SRCS 是目标变量
# 仅能在 t1 内使用
t1: T1_SRCS := d.c
t1:
	@echo "SRCS: " $(SRCS)
	@echo "SRCS: " $(T1_SRCS)

t2:
	@echo "SRCS: " $(SRCS)
	@echo "SRCS: " $(T1_SRCS)