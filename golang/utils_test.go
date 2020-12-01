package main

import "testing"

func TestCutoff64(t *testing.T) {
	v := cutoff64(10)
	if v != 1844674407370955162 {
		t.Fatalf(`show return 1 actural value is %v`, v)
	}
}
