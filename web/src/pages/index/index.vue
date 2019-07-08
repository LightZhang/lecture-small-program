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
          <div class="today-news">{{data.recommendation.name}}</div>
        </div>
        <div class="right">
          <van-icon name="like" />
        </div>
      </div>
      <div class="news boder">
        <h2 class="title">新闻</h2>
        <ul>
          <li v-for="item in data.news" :key="item.name">
            {{item.name}}
          </li>
        </ul>
      </div>
      <div class="recommended-read boder">
        <h2 class="title">推荐阅读</h2>
        <ul>
          <li v-for="item in data.recommendedReads" :key="item.name">
            {{item.name}}
          </li>
        </ul>

      </div>
      <div class="hot-top boder">
        <h2 class="title">热点专题</h2>
        <ul>
          <li v-for=" hot in data.hotTops" :key="hot.name">
            {{hot.name}}
          </li>
        </ul>
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
      data: {
        recommendation: {
          name: '感恩陈总缘系统如何带好团队',
          icon: '',
          date: ''
        },
        news: [
          { name: '技术选型的4个参考原则', },
          { name: '从大公司转型创业的七个采坑经验', },
          { name: '大数据赋能智慧城市建设' },
          { name: '前端技术未来展望之路' }
        ],
        recommendedReads: [
          { name: '代码规范，代码长治久安的基础' },
          { name: '从工程师到管理者我的思考与实现' },
          { name: '稳定性实践：开关和预案' },
        ],
        hotTops: [
          { name: '前端训练营' },
          { name: '即可时间训练营' }
        ]
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

