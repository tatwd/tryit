package com.test;

import java.sql.*;

import com.test.Connections;

public class TestConnection {

	public static void main(String[] args) {

		Connections connecter = new Connections("MySQL", "com.mysql.jdbc.Driver", "jdbc:mysql://localhost:3306/test", "root", "root");

		try {

			connecter.queryDatabase("SELECT * FROM user_info");

			ResultSet result = connecter.getResult();

			// 遍历结果集

			System.out.println("------------------");
			System.out.println("ID\tUsername");
			System.out.println("------------------");

			while(result.next()) {

				String id       = result.getString("id");
				String username = result.getString("username");

				String rs = String.format("%s\t%s", id, username);

				System.out.println(rs);
			}

			System.out.println("-----------------");

			connecter.allClose(); // 关闭所以资源

		} catch (SQLException e) {

			e.printStackTrace();
		}

	}

}
