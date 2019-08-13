<template>
    <div class="video-shuffle can-be-moved" style="height: 529px; width: 100%; position: fixed; top: 0px;">
        <div class="story-video-overlay"></div>
        <video loop="loop" autoplay="autoplay" poster="https://static0.fitbit.com/simple.b-cssdisabled-jpg.h96a0cd6e3468e7d6c0a88055d30c496b.pack?items=%2Fcontent%2Fassets%2Fwhy%2Fimages%2Fintro_01.jpg" style="width: 100%; margin-left: 0px;">
            <source src="http://cache.fitbit.com/media/us/story/fitbit4.mp4" type="video/mp4">
            <source src="http://cache.fitbit.com/media/us/story/fitbit5.webm" type="video/webm">
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