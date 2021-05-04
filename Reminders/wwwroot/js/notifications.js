var myInterval;

function showNotification() {

    let $descriptions = $(".card-text");
    let $dueDates = $("input.fullDate");
    let $cards = $("div.card");
    let now = new Date();

    $('.card-title').each(async function (index) {
        if (isSameTime($dueDates[index], now)) {
            console.log(`the times ${$($dueDates[index]).attr('value')} and ${now} DO match!`);
            await playSound("http://localhost:14919/js/notification_sound.mp3");
            const notification = new Notification("Alarm", {
                body: $($descriptions[index]).text()
            });
            $($cards[index]).remove();

            idToRemove = $($cards[index]).attr("data-id");

            $.ajax({
                url: `http://localhost:14919/api/alarm/delete/${idToRemove}`,
                method: 'DELETE'
            }).done(function () {
                alert('Your alarm has been deleted.');
            });
        }

        else {
            console.log(`the times ${$($dueDates[index]).attr('value')} and ${now} do NOT match.`);
        }
        
    });

}

function isSameTime(dateVals, now) {
    let date = $(dateVals).attr("value").split(" ");
    let year = parseInt(date[0]);
    let month = parseInt(date[1]);
    let day = parseInt(date[2]);
    let hour = parseInt(date[3]);
    let minute = parseInt(date[4]);

    //console.log(year + ":" + now.getFullYear() + "comparision result is " + year === now.getFullYear());

    //console.log(month + ":" + now.getMonth() + 1 + "comparision result is " + month === now.getMonth() + 1);

    //console.log(day + ":" + now.getDate() + "comparision result is " + day === now.getDay());

    //console.log(hour + ":" + now.getHours() + "comparision result is " + hour === now.getHours());

    //console.log(minute + ":" + now.getMinutes() + "comparision result is " + minute === now.getMinutes());
    
    if (year === now.getFullYear() && (month === now.getMonth() + 1) && day === now.getDate() && hour === now.getHours() && minute === now.getMinutes()) {

        return true;
    }

    return false;
}

async function playSound(url) {
    $('body').append(`<audio id="myAudio" src="${url}">`);
    document.getElementById("myAudio").play();
    await new Promise(r => setTimeout(r, 2000));
    $('audio').remove('#myAudio');
}


$('document').ready(() => {
    $('#notifyBtn').click(async () => {

        if (Notification.permission === "granted") {
            $('#notifyBtn').removeClass("btn-primary");
            $('#notifyBtn').addClass("btn-secondary");
            $('#notifyBtn').attr("disabled", true);
            $('#notifyBtn').text("Notifications enabled!")

            clearInterval(myInterval);
            myInterval=setInterval(showNotification, 1000*30);
        }

        else if (Notification.permission !== "denied") {
            Notification.requestPermission().then(permission => {
                clearInterval(myInterval);
                setInterval(showNotification, 1000 * 30);
            })
            //showNotification();
        }

    });
});