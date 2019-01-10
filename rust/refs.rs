fn main() {
	let foo: i32 = 1111;
	println!("foo: {} &foo: {}", foo, &foo);

	let mut bar = &foo;
	println!("bar: {}", bar);
	bar = &1996;
	println!("foo: {} bar: {}", foo, bar);

	let ref mut p = &foo;
	*p = &1996;
	println!("foo: {} *p: {}", foo, *p);
}
