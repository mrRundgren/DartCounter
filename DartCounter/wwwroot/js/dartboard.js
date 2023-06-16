let currentDartboardItem = null;
export async function dartboardInit(svg) {
    svg.addEventListener('click', dartboardClick);
    return currentDartboardItem;
}

export function dartboardClick(x, y) {
    return document.elementsFromPoint(x, y)[0].getAttribute('id');
}