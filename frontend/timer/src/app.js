import Timer from './timer';

const timer = new Timer(5);
timer.start();

setTimeout(() => {
  console.log('pause');
  timer.pause();
}, 3000);

setTimeout(() => {
  console.log('restart');
  timer.restart();
}, 5000);
