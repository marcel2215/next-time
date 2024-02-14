window.shareLink = function (title, url) {
  navigator.share && navigator.share({ title: title, text: 'Choose when you are available to take part in this event!', url: url })
    .then(() => console.log('Successful share'))
    .catch((error) => console.log('Error sharing', error));
}
