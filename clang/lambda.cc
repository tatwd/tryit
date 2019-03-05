#include <iostream>

int main(void)
{
	int b = 1;
    int a = [b](int a) { /* Lambda 表达式 C++11*/
        std::cout << b << " hello world\n";
        return ++a;
    }(b);
    std::cout << a << std::endl;
}
