window.shareLink = function(title, url) {
  navigator.share && navigator.share({ title: title, text: 'Check out this link!', url: url })
    .then(() => console.log('Successful share'))
    .catch((error) => console.log('Error sharing', error));
}
