fn main() {
    let s = String::from("hello world!");
    let a = s;

	/*
	s --> ptr --x--"hello world"
	a --> ptr -----------^
	*/

    // error: value used here after move
    // println!("s: {}", s);
    println!("a: {}", a);
}
