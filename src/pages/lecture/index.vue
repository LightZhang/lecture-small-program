
 <template>
  <div>
    <div class="paly-box">
      <van-icon v-if="isStopRecord" name="play" />
      <van-icon v-else name="stop" @click="stopRecord" />
    </div>

  </div>

</template>

<script>
export default {
  data() {
    return {
      isStopRecord: true,
      recorderManage: null
    };
  },
  created() {
    this.init();
  },
  methods: {

    init() {
      this.recorderManage = mpvue.getRecorderManager();

      this.recorderManage.onStart(function () {
        console.log("开始录音");
      });

      this.recorderManage.onStop(function (res) {
        console.log(res.tempFilePath);
        console.log("结束录音");
      });


    },

    startRecord() {
      this.isStopRecord = false;
      this.recorderManage.start();
    },
    stopRecord() {
      this.isStopRecord = true;
      this.recorderManage.stop();
    }

  }

}
</script>

<style >
.paly-box {
  font-size: 30px;
  color: aqua;
}
</style>
