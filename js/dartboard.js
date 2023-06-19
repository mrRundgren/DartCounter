let currentDartboardItem = null;
export async function dartboardInit(svg) {
    svg.addEventListener('click', dartboardClick);
    return currentDartboardItem;
}

export function dartboardClick(x, y) {
    var element = document.elementsFromPoint(x, y)[0];
    var id = element.getAttribute('id');

    if (id != "miss") {
        var dart = document.createElement('div');

        dart.className = "dartboard-dart"
        dart.style.top = ((y - 5) + document.documentElement.scrollTop) + "px";
        dart.style.left = ((x - 5) + document.documentElement.scrollLeft) + "px";
        document.body.appendChild(dart);
    }

    return id;
}

export function hideDarts() {
    let get = document.querySelectorAll('.dartboard-dart');
    get.forEach(dart => {
        dart.classList.add('hidden');
    });
}

export function showDarts() {
    let get = document.querySelectorAll('.dartboard-dart');
    get.forEach(dart => {
        dart.classList.remove('hidden');
    });
}

export function removeDarts() {
    let get = document.querySelectorAll('.dartboard-dart');
    get.forEach(element => {
        element.remove();
    });
}