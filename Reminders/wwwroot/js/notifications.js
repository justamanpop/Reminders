function showNotification() {

    let $descriptions = $(".card-text");

    $('.card-title').each(async function (index) {
        await playSound("http://localhost:14919/js/notification_sound.mp3");
        const notification = new Notification("Alarm", {
            body: $($descriptions[index]).text()
        });
    });
}

async function playSound(url) {
    $('body').append(`<audio id="myAudio" src="${url}">`);
    document.getElementById("myAudio").play();
    await new Promise(r => setTimeout(r, 2000));
    $('audio').remove('#myAudio');
}

$('document').ready(() => {
    console.log("in doc ready");
    $('#notifyBtn').click(async () => {
        console.log("I was reached")
        if (Notification.permission === "granted") {
            $('#notifyBtn').removeClass("btn-primary");
            $('#notifyBtn').addClass("btn-secondary");
            $('#notifyBtn').attr("disabled", true);
            $('#notifyBtn').text("Notifications enabled!")

            setTimeout(showNotification, 2000);
        }

        else if (Notification.permission !== "denied") {
            Notification.requestPermission().then(permission => {
                showNotification();
            })
            showNotification();
        }
    });
});