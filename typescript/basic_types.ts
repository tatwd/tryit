// 基础类型
//
// Boolean Number String Null Undefined Symbol
// Array Tuple Enum Any Void Never Object
//
// more info to visit https://www.typescriptlang.org/docs/handbook/basic-types.html

// 1 布尔值
let isDone: boolean = true;
console.log(isDone);
// true

// 2 数字
let dec: number = 1; // 十进制
let hex: number = 0xfd; //十六进制
let bin: number = 0b1010; // 二进制
let oct: number = 0o744; // 八进制
console.log(dec, hex, bin, oct);
// 1 253 10 484

// 3 字符串
let name1: string = "Jaron King";
console.log(typeof(name1));
// string

let name2: string = `Gene`;
let age: number = 37;
let sentence: string = `Hello, my name is ${ name2 }.

I'll be ${ age + 1 } years old next month.`;
// let sentence: string = "Hello, my name is " + name + ".\n\n" +
//     "I'll be " + (age + 1) + " years old next month.";
console.log(sentence);
// Hello, my name is Gene.
//
// I'll be 38 years old next month.

// 4 数组
let arr1: number[] = [1, 2, 3];
let arr2: Array<number> = [4, 5, 6];

// 5 元组
let t1: [string, number] = ['hello', 11];
console.log(t1[0].substr(1));
// ello

// console.log(t1[1].substr(1)); // Error, 'number' does not have 'substr'

// // 当访问一个越界的元素，会使用 `联合类型` 替代
// t1[3] = 'world'; // OK, 字符串可以赋值给(string | number)类型
// console.log(t1); // OK, 'string' 和 'number' 都有 toString
// // t1[6] = true; // Error, 布尔不是(string | number)类型

// 6 枚举
// 默认情况下，从0开始为元素编号
enum Color1 { Red, Green, Blue }
let c1: Color1 = Color1.Green;
console.log(c1);
// 1

// 全部都采用手动赋值
enum Color2 {Red = 1, Green = 2, Blue = 4}
let c2: Color2 = Color2.Green;

// get name of a Enum
let colorName: string = Color2[2]; // 2 is value not index
console.log(colorName);
// Green

// 7 Any
// 不清楚类型的变量指定一个类型
// 在对现有代码进行改写的时候，any类型是十分有用的
let notSure: any = 4;
notSure = "maybe a string instead";
notSure = false; // okay, definitely a boolean

let list: any[] = [1, true, "free"];
list[1] = 100;


// 8 Void
// 与any类型相反 表示没有任何类型
function warnUser(): void {
    console.log("This is my warning message");
}

// 只能为它赋予 undefined 和 null
let unusable: void = undefined; // or null

// 9 Null 和 Undefined
// 默认情况下null和undefined是所有类型的子类型
let u: undefined = undefined;
let n: null = null;

// 10 Never
// 永不存在的值的类型
// 抛出异常或根本就不会有返回值的函数表达式或箭头函数表达式的返回值类型
// never类型，当它们被永不为真的类型保护所约束
// 返回never的函数必须存在无法达到的终点
// never类型是任何类型的子类型，也可以赋值给任何类型

// 抛出异常
function error(message: string): never {
  throw new Error(message);
}

// 推断的返回值类型为 never
function fail() {
  return error("Something failed");
}

// 返回 never 的函数必须存在无法达到的终点
function infiniteLoop(): never {
  while (true) {
  }
}

// 11 Object
// 非原始类型
declare function create(o: object | null): void;

create({ prop: 0 }); // OK
create(null); // OK

// create(42); // Error
// create("string"); // Error
// create(false); // Error
// create(undefined); // Error

// 12 类型断言
// 只是在编译阶段起作用
// JSX中，只有 as语法断言是被允许的
let someValue: any = "this is a string";
let strLength1: number = (<string>someValue).length;
let strLength2: number = (someValue as string).length;
console.log(strLength1, strLength2);
