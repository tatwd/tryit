#![crate_name = "mymath"] // lib name
#![crate_type = "cdylib"] // c dynamic lib

#[no_mangle] // tell the Rust compiler not to mangle the name of this function
			 // Mangling is when a compiler changes the name we’ve given a
			 // function to a different name that contains more information for
			 // other parts of the compilation process to consume but is less
			 // human readable.
pub extern "C" fn add(x: i32, y: i32) -> i32 {
    return x + y;
}
