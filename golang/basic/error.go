package main

import (
	"fmt"
)

// a test method
func testMethod() int {
	return 1
}

// DivideError struct
type DivideError struct {
	dividee int // 除数
	divider int // 被除数
}

// implements `error` interface
func (de *DivideError) Error() string {
	strFormat := `
    Cannot proceed, the divider is 0.
    dividee: %d
    divider: 0
    `
	return fmt.Sprintf(strFormat, de.dividee)
}

// Divide func to solve `int` numbers
func Divide(varDividee, varDivider int) (result int, errorMsg string) {
	if varDivider == 0 {
		dData := DivideError{
			dividee: varDividee,
			divider: varDivider,
		}
		errorMsg = dData.Error()
	} else {
		result = varDividee / varDivider
		errorMsg = ""
	}
	// return result, errorMsg
	return
}
