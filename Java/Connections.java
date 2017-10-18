package com.test;

import java.sql.*;

public class Connections {
	
	private String databaseType   = null; // 数据库类型
	private String databaseDriver = null; // 数据库驱动
	private String databaseUrl    = null; // 数据库地址
	
	private String username       = null; // 用户姓名
	private String password       = null; // 用户密码
	
	private Connection connecter = null;
	private Statement  statement = null;
	private ResultSet  result    = null;
	
	public Connections(String databaseType, String databaseDriver, String databaseUrl, String username, String password) {
		
		this.setDatabaseType(databaseType);
		
		this.setDatabaseDriver(databaseDriver);
		
		this.setDatabaseUrl(databaseUrl);
		
		this.setUsername(username);
		
		this.setPassword(password);
	}
	
	// 连接数据库
	
	public void connect() {
		
		if(this.databaseType == "MySQL") {
			
			try {
				Class.forName(this.databaseDriver);
				
				this.connecter = DriverManager.getConnection(this.databaseUrl, this.username, this.password); // 获取连接
				
			} catch (Exception e) {
				e.printStackTrace();
			}
		}
	}
	
	// 查询数据库
	
	public void queryDatabase(String queryString) throws SQLException {
		if (this.connecter == null) {
			this.connect(); // 创建连接对象
		}
		
		this.statement = this.connecter.createStatement();
		this.result    = statement.executeQuery(queryString);
	}
	
	public void allClose() throws SQLException {
		if(!this.result.isClosed()) {
			this.result.close();
			
			//System.out.println("1");
		}
		
		if(!this.statement.isClosed()) {
			this.statement.close();
			
			//System.out.println("2");
		}
		
		if(!this.connecter.isClosed()) {
			this.connecter.close();
			
			//System.out.println("3");
		}
		
		System.out.println("Closed all resources!");
	}
	
	public String getDatabaseType() {
		return this.databaseType;
	}
	
	public void setDatabaseType(String databaseType) {
		this.databaseType = databaseType;
	}

	public String getDatabaseDriver() {
		return databaseDriver;
	}

	public void setDatabaseDriver(String databaseDriver) {
		this.databaseDriver = databaseDriver;
	}

	public String getDatabaseUrl() {
		return databaseUrl;
	}

	public void setDatabaseUrl(String databaseUrl) {
		this.databaseUrl = databaseUrl;
	}

	public String getUsername() {
		return username;
	}

	public void setUsername(String username) {
		this.username = username;
	}

	public String getPassword() {
		return password;
	}

	public void setPassword(String password) {
		this.password = password;
	}

	public Statement getStatement() {
		return statement;
	}

	public void setStatement(Statement statement) {
		this.statement = statement;
	}

	public ResultSet getResult() {
		return result;
	}

	public void setResult(ResultSet result) {
		this.result = result;
	}
}
