// 公元前甲子对照表
const bcMap = {
  units: {
    9: ["壬", "戌", "申", "午", "辰", "寅", "子"],
    8: ["癸", "亥", "酉", "未", "巳", "卯", "丑"],
    7: ["甲", "子", "戌", "申", "午", "辰", "寅"],
    6: ["乙", "丑", "亥", "酉", "未", "巳", "卯"],
    5: ["丙", "寅", "子", "戌", "申", "午", "辰"],
    4: ["丁", "卯", "丑", "亥", "酉", "未", "巳"],
    3: ["戊", "辰", "寅", "子", "戌", "申", "午"],
    2: ["己", "巳", "卯", "丑", "亥", "酉", "未"],
    1: ["庚", "午", "辰", "寅", "子", "戌", "申"],
    0: ["辛", "未", "巳", "卯", "丑", "亥", "酉"],
  },
  tens: [
    {
      3: 1,
      2: 2,
      1: 3,
      0: 4,
      9: 1,
      8: 2,
      7: 3,
      6: 4,
      5: 5,
      4: 6,
    },
    {
      1: 1,
      0: 2,
      7: 1,
      6: 2,
      5: 3,
      4: 4,
      3: 5,
      2: 6,
      9: 5,
      8: 6,
    },
    {
      5: 1,
      4: 2,
      3: 3,
      2: 4,
      1: 5,
      0: 6,
      9: 3,
      8: 4,
      7: 5,
      6: 6,
    },
  ],
};

// 公元后甲子对照表
const adMap = {
  units: {
    0: ["庚", "申", "午", "辰", "寅", "子", "戌"],
    1: ["辛", "酉", "未", "巳", "卯", "丑", "亥"],
    2: ["壬", "戌", "申", "午", "辰", "寅", "子"],
    3: ["癸", "亥", "酉", "未", "巳", "卯", "丑"],
    4: ["甲", "子", "戌", "申", "午", "辰", "寅"],
    5: ["乙", "丑", "亥", "酉", "未", "巳", "卯"],
    6: ["丙", "寅", "子", "戌", "申", "午", "辰"],
    7: ["丁", "卯", "丑", "亥", "酉", "未", "巳"],
    8: ["戊", "辰", "寅", "子", "戌", "申", "午"],
    9: ["己", "巳", "卯", "丑", "亥", "酉", "未"],
  },
  tens: [
    {
      4: 1,
      5: 2,
      6: 3,
      7: 4,
      8: 5,
      9: 6,
      0: 3,
      1: 4,
      2: 5,
      3: 6,
    },
    {
      0: 5,
      1: 6,
      2: 1,
      3: 2,
      4: 3,
      5: 4,
      6: 5,
      7: 6,
      8: 1,
      9: 2,
    },
    {
      0: 1,
      1: 2,
      2: 3,
      3: 4,
      4: 5,
      5: 6,
      6: 1,
      7: 2,
      8: 3,
      9: 4,
    },
  ],
};

/**
 * 公元纪年转农历纪年
 * @param {number} ceYear 公元纪元年份
 */
function ce2lunisolar(ceYear, yearType) {
  if (ceYear == 0) return "unknown";
  var u = ceYear % 10;
  var t = ~~((ceYear / 10) % 10);
  var o = ~~(ceYear / 100);
  if (o > 32) return "unknown";
  var r = o % 3;
  var oIdx = r === 0 ? r + 2 : r === 2 ? r - 2 : 1;

  var map = yearType == -1 ? bcMap : adMap;
  var row = map.units[u];
  return row[0] + row[map.tens[oIdx][t]];
}
