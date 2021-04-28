function updateTime() {
    var d = new Date().toLocaleTimeString();
    var ele = document.getElementById("myTime");
    ele.innerHTML = `The time is ${d}`;
}

setInterval(updateTime, 100);