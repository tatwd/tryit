# 命令及结果同时显示
# 发生错误时不执行之后的命令
all:
	echo "> I want to see the hello.txt."
	cat hello.txt
	echo "> but has error: not found the file."

# 只显示结果
# 发生错误时不执行之后的命令
use@:
	@echo "> I want to see the hello.txt."
	@cat hello.txt
	@echo "> but has error: not found the file."

# 命令及结果同时显示
# 发生错误时也执行之后的命令
use-:
	-echo "> I want to see the hello.txt."
	-cat hello.txt
	-echo "> but has error: not found the file."