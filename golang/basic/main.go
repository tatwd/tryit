package main

import (
	"fmt"
	"os"
)

// var a int // => 0

func main() {
	// fmt.Println("Hello Go!", "I am Leo.")

	// a := 2
	// if a < 4 {
	// 	fmt.Println("Hello Go!", "I am Leo.")
	// }

	// a := 2
	// b := 3
	// arr := [5]int{1, 2, 3, 4, 5}

	// for a < b {
	// 	fmt.Println("a < b")
	// 	a++
	// }
	// for i := 0; i < 3; i++ {
	// 	fmt.Printf("i => %d\n", i)
	// }
	// for index, value := range arr {
	// 	fmt.Printf("%d => %d\n", index, value)
	// }

	// test := testMethod()
	// fmt.Println(test)

	// a, b := swap("Leo", "Hello")
	// fmt.Println(a, b)

	// getPow := func(x, y float64) float64 {
	// 	return math.Pow(x, y)
	// }
	// fmt.Println(getPow(2, 3))

	// next := getClosure()
	// fmt.Println(
	// 	"next:", next(), next())
	// next1 := getClosure()
	// fmt.Println(
	// 	"next1:", next1(), next1())

	// c1 := Circle{
	// 	radius: 2.1}
	// fmt.Println(c1.getArea())

	// default value
	// var a int // => 0
	// var a float32 // => 0
	// var a *int // => nil
	// fmt.Println(a)

	// a := 2
	// var p *int
	// p = &a
	// fmt.Printf("p=>%x *p=>%d\n", p, *p)

	// arr := [...]int{2, 4, 6}

	// // Slice
	// slice := []int{1, 3, 5, 7, 9}
	// // slice := make([]int, 5, 9)
	// slice = append(slice, 11, 13)
	// fmt.Println(
	// 	arr,
	// 	len(arr),
	// 	len(slice),
	// 	cap(slice),
	// 	slice,
	// 	slice[1:4],
	// 	slice[:2],
	// 	slice[2:],
	// )

	// Map
	// var testMap map[string]string
	// testMap := make(map[string]string)
	// testMap["name"] = "leo"
	// // for key := range testMap {
	// // 	fmt.Printf("%s => %s", key, testMap[key])
	// // }
	// for key, value := range testMap {
	// 	fmt.Printf("%s => %s\n", key, value)
	// }
	// _, ok := testMap["age"]
	// if ok {
	// 	fmt.Println("has age!")
	// } else {
	// 	fmt.Println("no age!")
	// }

	// countryCapitalMap := map[string]string{
	// 	"France": "Paris",
	// 	"Italy":  "Rome",
	// 	"Japan":  "Tokyo",
	// 	"India":  "New Delhi",
	// }
	// fmt.Println(countryCapitalMap)
	// delete(countryCapitalMap, "France")
	// fmt.Println("Entry for France is deleted => ", countryCapitalMap)

	// var phone Phone

	// phone = new(IPhone)
	// phone.call()

	// phone = new(NokiaPhone)
	// phone.call()

	// Error Catch

	// // 正常情况
	// if result, errorMsg := Divide(100, 10); errorMsg == "" {
	// 	fmt.Println("100/10 = ", result)
	// }
	// // 当被除数为零的时候会返回错误信息
	// if _, errorMsg := Divide(100, 0); errorMsg != "" {
	// 	fmt.Println("errorMsg is: ", errorMsg)
	// }

	f, err := os.Open("./test.txt")
	if err != nil {
		fmt.Println(err)
		return
	}
	fmt.Println(f.Name(), "opened successfully")
}

// return multi values
func swap(a, b string) (string, string) {
	return b, a
}

// closure
func getClosure() func() int {
	i := 0
	return func() int {
		i++
		return i
	}
}

// Circle Struct Defined
type Circle struct {
	radius float64
}

// method for a struct
func (c Circle) getArea() float64 {
	return 3.14 * c.radius * c.radius
}

// Phone interface
type Phone interface {
	call()
}

// IPhone struct to implements interface
type IPhone struct {
}

func (iphone IPhone) call() {
	fmt.Println("I am iPhone, I can call u!")
}

// NokiaPhone struct to impl interface
type NokiaPhone struct {
}

func (nokiaPhone NokiaPhone) call() {
	fmt.Println("I am Nokia, I can call u!")
}
