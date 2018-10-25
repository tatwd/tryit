// ES6
export default class Timer {
  constructor(second) {
    this.second = second;
    this.id = 0;
  }

  start() {
    console.log(this.second);
    this.second--;
    this.id = window.setTimeout(() => {
      this.second >= 0 ? this.start() : this.pause();
    }, 1000);
  }

  pause() {
    window.clearTimeout(this.id);
  }

  restart() {
    this.start();
  }
}
