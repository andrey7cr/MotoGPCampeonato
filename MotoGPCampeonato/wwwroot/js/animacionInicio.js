document.addEventListener("DOMContentLoaded", function () {
    const luces = [
        document.getElementById("luz1"),
        document.getElementById("luz2"),
        document.getElementById("luz3"),
        document.getElementById("luz4"),
        document.getElementById("luz5")
    ];

    let i = 0;
    let intervalo = setInterval(() => {
        if (i < luces.length) {
            luces[i].style.opacity = 0;
            i++;
        } else {
            clearInterval(intervalo);
        }
    }, 500);

    // Oculta la animación luego de 6s
    setTimeout(() => {
        document.getElementById("animacionInicio").style.display = "none";
    }, 6000);
});
