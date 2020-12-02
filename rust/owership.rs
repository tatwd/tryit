fn main() {
	// 字符串默认采用utf8编码
	let s1 = String::from("hello 世界");

	println!("s1:{}, len:{}", s1, s1.len());
	println!("s1:{}, get_borrowed_string_size(&s1):{}", s1, get_borrowed_string_size(&s1));
	println!("get_moved_string_size(s1):{}", get_moved_string_size(s1));
	// Now s1 is dropped!

	let s2 = "hello 世界";
	println!("s2:{}, get_moved_string_size(&s2):{}", s2, get_real_string_size(&s2));
}

fn get_real_string_size(s: &str) -> usize {
	s.chars().count()
}

fn get_moved_string_size(s: String) -> usize {
	s.len()
}

fn get_borrowed_string_size(s: &String) -> usize {
	s.len()
}
