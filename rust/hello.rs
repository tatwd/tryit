fn main() {
    // Define a variable:
    // `let [mut] var_name[: data_type] [= init_value];`

    // Immutable variable
    // `foo` can not be assigned twice
    let foo: i32 = 1111;
    println!("foo: {}", foo);

    // Mutable variable
    // `bar` can be assigned
    let mut bar: bool = true;
    println!("bar: {}", bar);
    bar = false;
    println!("bar: {}", bar);

    // Tuple
    let t: (i32, f64, char) = (1, 0.5, 'a');
    println!("t: {:?}, t.0: {}", t, t.0);

    let (_, _, x) = t;
    println!("x: {}", x);

    // Array
    let arr: [i32; 3] = [1996, 11, 11];
    println!(
        "arr: {:?}, length: {}, size_of_val: {}",
        arr,
        arr.len(),
        std::mem::size_of_val(&arr)
    );

    // Slice
    // [start_index..size]
    let sli = &arr[0..2]; // eq &[..2]
    println!("sli: {:?}", sli); // sli: [1996, 11]
}
