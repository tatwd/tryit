```bash
$ make --help
用法：make [选项] [目标] ...
选项：
  -b, -m                      为兼容性而忽略。
  -B, --always-make           无条件制作 (make) 所有目标。
  -C 目录, --directory=目录    在执行前先切换到 <目录>。
  -d                          打印大量调试信息。
  --debug[=旗标]               打印各种调试信息。
  -e, --environment-overrides
                              环境变量覆盖 makefile 中的变量。
  --eval=字串               将 <字串> 作为 makefile 语句估值。
  -f 文件, --file=文件, --makefile=文件
                              从 <文件> 中读入 makefile。
  -h, --help                  打印该消息并退出。
  -i, --ignore-errors         忽略来自命令配方的错误。
  -I 目录, --include-dir=目录  在 <目录> 中搜索被包含的 makefile。
  -j [N], --jobs[=N]          同时允许 N 个任务；无参数表明允许无限个任务。
  -k, --keep-going            当某些目标无法制作时仍然继续。
  -l [N], --load-average[=N], --max-load[=N]
                              在系统负载高于 N 时不启动多任务。
  -L, --check-symlink-times   使用软链接及软链接目标中修改时间较晚的一个。
  -n, --just-print, --dry-run, --recon
                              只打印命令配方，不实际执行。
  -o 文件, --old-file=文件, --assume-old=文件
                              将 <文件> 当做很旧，不必重新制作。
  -O[类型], --output-sync[=类型]
                           使用 <类型> 方式同步并行任务输出。
  -p, --print-data-base       打印 make 的内部数据库。
  -q, --question              不运行任何配方；退出状态说明是否已全部更新。
  -r, --no-builtin-rules      禁用内置隐含规则。
  -R, --no-builtin-variables  禁用内置变量设置。
  -s, --silent, --quiet       不输出配方命令。
  -S, --no-keep-going, --stop
                              关闭 -k。
  -t, --touch                 touch 目标（更新修改时间）而不是重新制作它们。
  --trace                     打印跟踪信息。
  -v, --version               打印 make 的版本号并退出。
  -w, --print-directory       打印当前目录。
  --no-print-directory        关闭 -w，即使 -w 默认开启。
  -W 文件, --what-if=文件, --new-file=文件, --assume-new=文件
                              将 <文件> 当做最新。
  --warn-undefined-variables  当引用未定义变量的时候发出警告。

该程序为 x86_64-pc-msys 编译
报告错误到 <bug-make@gnu.org>
```