using UnityEngine;

namespace MySample
{
    /// <summary>
    /// 기본 클래스의 싱글톤 패턴
    /// </summary>
    public class SingletonClass
    {
        //SingletonClass 클래스의 인스턴스(객체) 정적(static) 변수 선언
        private static SingletonClass instance;

        //public한 속성으로 private한 instance 에 전역적으로 접근하기
        public static SingletonClass Instance
        {
            get
            { 
                if (instance == null)
                {
                    //인스턴스 생성
                    instance = new SingletonClass();
                }
                return instance; 
            }
        }

        //public한 메서드로 private한 instance에 전역적으로 접근하기
        /*public static SingletonClass Instance()
        {
            if (instance == null)
            {
                instance = new SigletonClass();
            }
            return instance;
        }*/

        //필드 : 인스턴스이름.number -> Instance.number
        public int number;

    }

    
}