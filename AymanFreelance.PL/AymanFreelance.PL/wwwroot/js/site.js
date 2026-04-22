$(document).ready(function () {
    let params = new URLSearchParams(window.location.search);
    // Example: get parameter by name
    let MainSearchWord = params.get("MainSearchWord");
    if (MainSearchWord != null) {
        document.getElementById("MainSearchWord").value = MainSearchWord;
    }

});