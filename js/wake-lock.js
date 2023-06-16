export async function wakeLockInit() {
    if ("wakeLock" in navigator) {
        await requestWakeLock();
        document.addEventListener("visibilitychange", async () => {
            if (window.WakeLock !== null && document.visibilityState === "visible") {
                await requestWakeLock();
            }
        });
    }
}

async function requestWakeLock() {
    window.WakeLock = await navigator.wakeLock.request("screen");
    window.WakeLock.addEventListener("release", () => {
        console.log("Wake lock inactive");
    });
    console.log("Wake lock active");
}
