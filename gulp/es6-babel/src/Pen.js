class Pen {
  constructor(str) {
    this.str = str;
  }

  logger() {
    if (console) {
      console.log(`${this.str}`);
    }
  }
}

export default Pen; // this is a class
