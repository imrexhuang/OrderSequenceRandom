package myutils;

//https://www.itread01.com/content/1539068395.html

import javax.validation.constraints.NotNull;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Random;

/**
 * @author: YuGenHai
 * @name: AbstractOrderSequenceRandom
 * @creation: 2018/9/21 16:57
 * @notes: svsp + yyyyMMdd + uuid /random
 * @notes: 生成訂單號工具類
 * 
 * 
 * 之前沒加鎖時候如果在幾個線程池裏放了幾百個線程同時生成的情況下是有極小的幾率會重復，因為還沒有做成單例類返回原因，加了鎖初步可以上線，後續在調整。
Java並發生成不重復訂單流水號
 */


public abstract class AbstractOrderSequenceRandom {
    /**
     * 訂單前綴
     */
    //private static final String ORDERPREFIX = "SVSP";
	private static final String ORDERPREFIX = "";
    /**
     * 時間戳
     */
    //private static final String FORMAT = "yyyyMMddHHmmss";
	private static final String FORMAT = "yyyyMMdd";
    /**
     * 數字隨機
     */
    public static final String numberChar = "0123456789";

    /**
     * 隨機數字
     */
    public static final int numberFor = 12;

    /**
     * @return
     * @author yugenhai
     */
    @NotNull
    public synchronized static String createOrderSnRandom() {
        return AbstractOrderSequenceRandomInner.createOrderSnRandomInner();
    }

    /**
     * 創建訂單號<svsp + yyyy-mm-dd + Random>
     *
     * @author yugenhai
     */
    private final static class AbstractOrderSequenceRandomInner {
        private synchronized static String createOrderSnRandomInner() {
            SimpleDateFormat sdf = new SimpleDateFormat(FORMAT);
            StringBuffer sb = new StringBuffer();
			
			//https://www.zfl9.com/java-lang-util.html
            //https://mp.weixin.qq.com/s/3CZNE4ZduyN1pdxvqP-7Ng
            //Random random = new Random(System.currentTimeMillis()); //模擬JDK 5之前版本取號重複問題
			
            Random random = new Random();
			
            for (int i = 0; i < numberFor; i++) {
                sb.append(numberChar.charAt( random.nextInt(numberChar.length()) ));
            }
            return ORDERPREFIX + sdf.format(new Date()) + sb.toString();
        }
    }
}
