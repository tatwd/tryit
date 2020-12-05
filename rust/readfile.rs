use std::io;
use std::io::prelude::*;
use std::io::BufReader;
use std::fs::File;
use std::collections::HashMap;

fn main() -> io::Result<()> {

	let f = File::open("./votes.txt")?;
	let mut reader = BufReader::new(f);
	let mut map = HashMap::new();

	loop {
		let mut line = String::new();
		if reader.read_line(&mut line)? <= 0 {
			break;
		}
		let name = line.trim().to_string();
		let v = match map.get(&name) {
			Some(&c) => c + 1,
			None => 1
		};
		map.insert(name, v);
	}

	for (k, v) in map.iter() {
		println!("{} => {}", k, v);
	}

	Ok(())
}
