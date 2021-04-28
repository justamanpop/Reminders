function showNotification() {

    let $descriptions = $(".card-text");

    $('.card-title').each(function (index) { 

        const notification = new Notification("Alarm", {
            body: $($descriptions[index]).text()
        });
    });
}

console.log(Notification.permission);

$('document').ready(() => {
    console.log("in doc ready");
    $('#notifyBtn').click(async () => {
        console.log("I was reached")
        if (Notification.permission === "granted") {
            $('#notifyBtn').removeClass("btn-primary");
            $('#notifyBtn').addClass("btn-secondary");
            $('#notifyBtn').attr("disabled", true);
            $('#notifyBtn').text("Notifications enabled!")

            setInterval(showNotification, 2000);
        }

        else if (Notification.permission !== "denied") {
            Notification.requestPermission().then(permission => {
                showNotification();
            })
            showNotification();
        }
    });
});