let currentDartboardItem = null;
export async function dartboardInit(svg) {
    svg.addEventListener('click', dartboardClick);
    return currentDartboardItem;
}

export function dartboardClick(x, y) {
    var id = document.elementsFromPoint(x, y)[0].getAttribute('id');
    var dart = document.createElement('div');
    dart.className = "dartboard-dart"
    dart.style.top = (y - 3) + "px";
    dart.style.left = (x - 3) + "px";
    document.body.appendChild(dart);
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