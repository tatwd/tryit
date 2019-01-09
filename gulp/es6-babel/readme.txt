旧版：

  - gulp 
  - gulp-babel 
  - babel-core 
  - babel-preset-es2015
  - gulp-browserify

====

Gulp ^8.0.0

Setup：

  # Babel 6
  npm install --save-dev gulp-babel

  # Babel 7
  npm install --save-dev gulp-babel@next @babel/core

  npm install @babel/preset-env --save-dev
  then add `.babelrc`

  # require('modules') in the browser
  npm install -g browserify

  npm run build

参考: 
  - https://babeljs.io/setup#installation
  - https://github.com/browserify/browserify#usage