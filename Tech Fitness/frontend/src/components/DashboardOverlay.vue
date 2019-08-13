<template>
    <div class="video-shuffle can-be-moved" style="height: 529px; width: 100%; position: fixed; top: 0px;">
        <div class="story-video-overlay"></div>
        <video loop="loop" autoplay="autoplay" poster="https://www.youtube.com/watch?time_continue=8&v=t3KrMH57Sl4" style="width: 100%; margin-left: 0px;">
            <source src="./src/assets/20182019 Banff Centre Mountain Film Festival World Tour (CanadaUSA).mp4" type="video/mp4">
        </video>
    </div>
</template>

<script>
export default {
    name: 'VideoOverlay',
}
</script>

<style>
video {
    object-fit: contain;
}
.video-shuffle {
    position: absolute;
    top: 0;
    left: 0;
    overflow: hidden;
    display: block;
}
.story-video-overlay {
    display: block;
    width: 100%;
    height: 100%;
    background-color: rgba(0,0,0,0.1);
    position: absolute;
    left: 0;
    top: 0;
    -webkit-transition: background-color 1s;
    transition: background-color 1s;
}
</style>