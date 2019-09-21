// DateTime Util

function isLeapYear(year) {
  return year % 4 === 0 && (year % 100 !== 0 || year % 400 === 0); 
}

function format(dt, fmt) {}

function addDays(dt, days) {
  var _dt = new Date(dt.valueOf());
  var newDays = _dt.getDate() + days;
  _dt.setDate(newDays);
  return _dt;
}

function addMonths(dt, months) {
  var _dt = new Date(dt.valueOf());
  var newMonth = _dt.getMonth() + 1 + months;
  _dt.setMonth(newMonth - 1);
  return _dt;
}

function addYears(dt, years) {
  var _dt = new Date(dt.valueOf());
  var newYear = _dt.getFullYear() + years;
  var month = _dt.getMonth() + 1;
  var day = _dt.getDate();
  _dt.setYear(newYear);
  /*if (month === 2 && !isLeapYear(newYear) && day === 29) {
    _dt.setMonth(1);
    _dt.setDate(28);
  }*/
  return _dt;
}

function span(dtStart, dtEnd) {
  var spanMS = dtEnd - dtStart;
  var fullYears = spanMS / (365.5 * 24 * 60 * 60 * 1000);
  var months = ~~fullYears * 12 + dtEnd.getMonth() - dtStart.getMonth();
  var fullDays = spanMS / (1 * 24 * 60 * 60 * 1000);
  var fullMinutes = spanMS / (1 * 60 * 1000);
  var fullSeconds = spanMS / (1 * 1000);
  return {
    years: ~~fullYears,
    fullYears,
    months,
    days: ~~fullDays,
    fullDays,
    minutes: ~~fullMinutes,
    fullMinutes,
    seconds: ~~fullSeconds,
    fullSeconds,
    milliSeconds: spanMS
  }
}

var dateTimeUtil = { 
  isLeapYear,
  format,
  addDays, 
  addMonths, 
  addYears,
  span
};

var dt = new Date(2019, 0, 31); // 2000/2/29
console.log('dt:', dt.toLocaleString());

var ret = dateTimeUtil.isLeapYear(dt.getFullYear());
console.log('[isLeapYear] ret:', ret);

ret = dateTimeUtil.addYears(dt, 10);
console.log('[addYears] ret:', ret.toLocaleString());

ret = dateTimeUtil.addMonths(dt, 1);
console.log('[addMonths] ret:', ret.toLocaleString());

ret = dateTimeUtil.addDays(dt, 10);
console.log('[addDays] ret:', ret.toLocaleString());

ret = dateTimeUtil.span(new Date(), dateTimeUtil.addDays(new Date(), 1));
console.log('[spanDays] ret:', ret);
/*
{
  days: 1
  fullDays: 1
  fullMinutes: 1440
  fullSeconds: 86400
  fullYears: 0.0027359781121751026
  milliSeconds: 86400000
  minutes: 1440
  months: 0
  seconds: 86400
  years: 0
}
*/
