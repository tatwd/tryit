package main

import (
	"fmt"
	"time"

	"github.com/jinzhu/gorm"
	_ "github.com/jinzhu/gorm/dialects/mssql"
)

// PmMaterial is a model of `pm_material` table
type PmMaterial struct {
	ID        string     `json:"id"`
	Title     string     `json:"title"`
	CreatedAt time.Time  `json:"created_at"`
	UpdatedAt *time.Time `json:"updated_at"`
}

// TableName override
func (PmMaterial) TableName() string {
	return "pm_material"
}

func main() {
	// 建立连接
	str := "server=localhost;user id=sa;password=root123;database=test_erp_sys;"
	// str := "sqlserver://sa:root123@localhost:1433?database=test_erp_sys"
	db, err := gorm.Open("mssql", str)
	if err != nil {
		panic(err.Error())
	}
	defer db.Close()

	// db.SingularTable(true)

	// 生成数据库表
	// db.AutoMigrate(&PmMaterial{})
	if !db.HasTable("pm_material") {
		fmt.Println("no pm_material")
		return
		// db.CreateTable(&PmMaterial{})
	}

	// 新增一条数据
	// now := time.Now().UTC()
	db.Create(&PmMaterial{ID: "1237", Title: "hello world"})

	// n, _ := time.Now().MarshalJSON()
	// n := time.Now().Format("2006-01-08 15:04:05")
	// fmt.Println(string(n))

	// 查询
	var item PmMaterial
	db.First(&item, "1235")
	fmt.Println(item)

	// 更新
	// db.Model(&item).Update("title", "jaron")

	// 删除
	// db.Delete(&item)
}
