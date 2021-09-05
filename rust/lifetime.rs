// 返回值（与传参关联）的生命周期与传参的生命周期（'a）必须一致
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
