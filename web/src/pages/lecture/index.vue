
 <template>
  <div id="lecture">
    <div class="content-box">
      <div class="time-box">
        <label>{{recorderTime}}</label>
        <label>/</label>
        <label>10:00</label>
      </div>
      <div class="paly-box">

        <div class="recor-circle">
          <div class="recor-aminite">
            <van-icon v-if="isPauseRecord" name="play" @click="startRecord" />
            <van-icon v-else name="pause" @click="pauseRecord" />

          </div>

        </div>

      </div>
      <div class="btn-box">
        <van-button size="small" round type="info" @click="stopRecord">重做</van-button>
        <van-button size="small" round type="info">保存</van-button>
      </div>
    </div>

  </div>

</template>

<script>
let recorderInterval = null;
export default {
  data() {
    return {
      isPauseRecord: true,
      recorderManage: null,
      recorderSecond: 0,

    };
  },
  computed: {
    recorderTime: function () {
      let minute = parseInt(this.recorderSecond / 60);
      let second = this.recorderSecond % 60;
      if (second < 10) {
        second = "0" + second;
      }
      if (minute < 10) {
        minute = "0" + minute;
      }

      return minute + ":" + second;
    }
  },
  mounted() {
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
      let _this = this;
      _this.isPauseRecord = false;
      _this.recorderManage.start();
      recorderInterval = setInterval(function () {
        _this.recorderSecond++;
        if (_this.recorderSecond >= 60 * 10) {
          clearInterval(recorderInterval);
        }
      }, 1000);

    },
    pauseRecord() {
      this.isPauseRecord = true;
      this.recorderManage.pause();
      clearInterval(recorderInterval);
      recorderInterval = null;
    },
    stopRecord() {
      this.isPauseRecord = true;
      this.recorderManage.stop();
      this.recorderSecond = 0;
      clearInterval(recorderInterval);
      recorderInterval = null;
    },



  }

}
</script>

<style lang="less" >
#lecture {
  position: absolute;
  bottom: 0rpx;
  width: 100%;

  .content-box {
    width: 100%;
    height: 200px;

    margin-top: 20px;

    .time-box {
      text-align: right;
      padding-right: 20px;
      margin-bottom: 30px;
    }

    .paly-box {
      font-size: 30px;
      color: cornflowerblue;
      display: flex;
      justify-content: center;
      .recor-circle {
        height: 80px;
        width: 80px;
        border-radius: 50%;
        background-color: rgba(43, 97, 228, 0.2);
        display: flex;
        justify-content: center;
        align-items: center;
        .recor-aminite {
          width: 30px;
          height: 30px;
          border-radius: 50%;
          border: solid 5px red;
          animation: floodlight 1s infinite;
          display: flex;
          justify-content: center;
          align-items: center;
          padding: 5px;
        }

        ._van-icon {
          display: flex;
          align-items: center;
        }
      }
    }

    .btn-box {
      display: flex;
      justify-content: space-between;
      ._van-button {
        margin: 10px 40px;
      }
    }
  }
}

@keyframes floodlight {
  0% {
    padding: 0px;
  }
  100% {
    padding: 15px;
  }
}
</style>
