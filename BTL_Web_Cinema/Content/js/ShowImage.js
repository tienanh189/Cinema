function ShowImage(imageUpLoader, previewImage) {
    if (imageUpLoader.files && imageUpLoader.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(previewImage).attr('src', e.target.result);
        }
        reader.readAsDataURL(imageUpLoader.files[0]);
    }
}