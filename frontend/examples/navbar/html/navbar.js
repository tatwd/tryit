var href = window.location.href;
var navlinks = [
  { text: 'Home', url: 'index.html' },
  { text: 'Foo', url: 'foo.html' },
  { text: 'Bar', url: 'bar.html' }
];

var createLinks = function(navlinks) {
  var res = '';
  navlinks.forEach(i => {
    var cls = href.indexOf(i.url) > -1 ? ' active' : '';
    res += `<a class="link${cls}" href="${i.url}">${i.text}</a>`;
  });
  return res;
};

var html = `
<style>
.link {
  color: #42b983;
  display: inline-block;
}
.link:not(:first-child) {
  margin-left: 15px;
}
.link.active {
  color: red;
}
</style>

<div class="navbar">
  <!--<a class="link" href="index.html">Home</a>
  <a class="link" href="foo.html">Foo</a>
  <a class="link" href="bar.html">Bar</a>-->
  ${createLinks(navlinks)}
</div>
`;

class AppNavbar extends HTMLDivElement {
  constructor() {
    super();

    let template = document.createElement('template');
    template.innerHTML = html;
    let templateContent = template.content;

    const shadowRoot = this.attachShadow({ mode: 'open' }).appendChild(
      templateContent.cloneNode(true)
    );
  }
}

customElements.define('app-navbar', AppNavbar, { extends: 'div' });
