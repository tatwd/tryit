package com.tatwd.test;

public class IsPowerOf2 {

	/**
	 * 判断数字是否是2的次方
	 */
	public static boolean isPowerOf2 (int number) {
		return (number & number - 1) == 0 ? true: false;
	}

	public static void main(String[] args) {

		boolean yes = isPowerOf2(4);

		System.out.println(yes);
	}

}
