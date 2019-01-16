""" 
Integers:
  Int8  Int16  Int32  Int64  Int128
  UInt8 UInt16 UInt32 UInt64 UInt128
  Bool
  BigInt

Floating-Point:
  Float16
  Float32
  Float64
"""
ans = typeof(1)
println(ans)

ans = typeof(1.0)
println(ans)

# Overflow behavior
i64_max = typemax(Int64)
ans = i64_max + 1
println(i64_max)
println(ans)
println(ans == typemin(Int64))

# Special floating-point values
# Inf: 无限大
# NaN: a value not == to any floating-point value (including itself)
ans = 1/Inf
println(ans)

ans = 1/0
println(ans)

ans = -5/0
println(ans)

ans = 0.1/0
println(ans)

ans = 1/0
println(ans)

ans = Inf / Inf
println(ans)
