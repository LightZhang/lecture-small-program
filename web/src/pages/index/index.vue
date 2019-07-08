<template>
  <div class="index">
    <div class="head">
      <swiper :indicator-dots="indicatorDots" :autoplay="autoplay" :interval="interval" :duration="duration">
        <block v-for="item in imgUrls" :key="item">
          <swiper-item>
            <image :src="item" class="slide-image" width="355" height="150" />
          </swiper-item>
        </block>
      </swiper>
    </div>

    <div class="content">
      <div class="recommended-today boder">
        <div class="left">
          <h2 class="title">今日推荐</h2>
          <div class="today-news">感恩陈总缘系统如何带好团队</div>
        </div>
        <div class="right">
          <van-icon name="like" />
        </div>
      </div>
      <div class="boder">
        <h2 class="title">新闻</h2>

      </div>
      <div class="boder">
        <h2 class="title">推荐阅读</h2>

      </div>
      <div class="boder">
        <h2 class="title">热点专题</h2>
      </div>
    </div>
  </div>
</template>

<script>
import card from '@/components/card'

export default {
  data () {
    return {
      imgUrls: [
        'https://images.unsplash.com/photo-1551334787-21e6bd3ab135?w=640',
        'https://images.unsplash.com/photo-1551214012-84f95e060dee?w=640',
        'https://images.unsplash.com/photo-1551446591-142875a901a1?w=640'
      ],
      indicatorDots: true,
      autoplay: false,
      interval: 5000,
      duration: 1000,
      userInfo: {

      }
    }
  },

  components: {
    card
  },

  methods: {

  },

  mounted () {


  }
}
</script>
<style lang="less" scoped>
.index {
  box-sizing: border-box;
  .content {
    display: flex;
    flex-direction: column;
    align-items: center;
    padding: 20rpx;

    .recommended-today {
      display: flex;
      flex-direction: row;
      align-items: center;
      height: 100px;
    }

    .boder {
      width: 100%;
      border: solid 1px #e0dddd;
      border-radius: 5px;
      padding: 10rpx;
      margin-top: 20rpx;
    }
  }
}
</style>

