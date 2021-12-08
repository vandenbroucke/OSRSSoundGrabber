const defaultReq = "https://oldschool.runescape.wiki/images/";
let urls = [];

// Per page; 
let items = $(".galleryfilename");
items.each((id, x) => {
  let startFileNamePos = x.href.lastIndexOf(":") + 1;
  let fileName = x.href.substring(startFileNamePos, x.href.length);
  urls.push(defaultReq + fileName);
});
console.log(urls);


const defaultReq = "https://oldschool.runescape.wiki/images/";
urls = [];

// Per page; 
let items = $("a[title*='File:']");
items.each((id, x) => {
  let startFileNamePos = x.href.lastIndexOf(":") + 1;
  let fileName = x.href.substring(startFileNamePos, x.href.length);
  urls.push(defaultReq + fileName);
});
console.log(urls);