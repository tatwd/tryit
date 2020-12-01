package main

import (
	"fmt"
	"unicode/utf8"
)

func main() {
	// default is utf-8 string
	// 一个中文字符 3 字节
	str := "hello 世界"
	fmt.Println("len(str):", len(str))                                        //12
	fmt.Println("len([]rune(str)):", len([]rune(str)))                        //8
	fmt.Println("len([]int32(str)):", len([]int32(str)))                      //8
	fmt.Println("utf8.RuneCountInString(str)):", utf8.RuneCountInString(str)) //8
}
