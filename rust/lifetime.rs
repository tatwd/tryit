fn max_val<'a>(a: &'a i32, b: &'a i32) -> &'a i32 {
	if a < b {
		b
	} else {
		a
	}
}

fn main() {
	let a = 1;
	let b = 2;
	let c = max_val(&a, &b);
	println!("max({},{}) = {}", a, b, c);
}
