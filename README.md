# Seat MES
시트MES 프로젝트

✔ **주제소개**
![MES소개](https://user-images.githubusercontent.com/91646481/142464015-a07f1a68-8bdd-4cc7-bebf-512e1b23a9dd.png)

✔ **프로젝트 요약**

- 자동차 시트 생산공정에서 필요한 MES프로그램 개발
- 공장 생산성을 개선하고 공장 리소스를 추적 및 동기화 가능하게 함
- 생산에서 발생하는 사안에 대한 실시간 정보를 통해 의사결정을 지원하는 MES시스템 구축

✔ **프로그램 구성 메뉴**

![구성메뉴](https://user-images.githubusercontent.com/91646481/142464839-f77a1db2-f3af-4b25-bf55-9de671dd1ea5.png)

✔ **주요 폼 소개**

- BOM
    - 상위품목(ALC)가 어떤 제품(FERT)로 구성되는지에 대한 정보를 표시
    - BOM을 통해 서로 다른 사양(SPEC)을 가진 상위품목(ALC)을 관리

![Untitled](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/94d71964-9bf2-4055-9b41-cb30b15407b1/Untitled.png)

- 작업지시
    - 수량을 입력하고 작업지시를 내리는 폼
    - 완제품(ALC) 수량을 기준으로 작업지시를 내리고 LH, RH로 나누어서 생산을 진행

![Untitled](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/e7e10a83-94ad-4022-b317-63935a1f1121/Untitled.png)

- 조립공정
    - 트랙적재 공정을 완료한 FERT(LH,RH)들을 표시
    - 조립공정을 완료 한 품목을 공정실적으로 데이터 처리
    - 공정 진행중인 품목의 SPEC과 정보들을 조회

![Untitled](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/aa5b8a25-4b1b-404d-b7aa-4c56a050b537/Untitled.png)

- 공정실적
    - 모든 공정을 마친 품목을 FERT(LH,RH)단위로 조회
    - 아래의 그래프를 통해 당일 작업완료도와 일별 생산수량(ALC)을 조회

![Untitled](https://s3-us-west-2.amazonaws.com/secure.notion-static.com/052ab4f9-92f2-41b7-81f5-4f3dd3d2c7d7/Untitled.png)

✔ **보완점**

- 실제 공정에서는 더욱 많은 하위품목과 SPEC, 공정, 라인이 존재하는 것을 고려해 이에 맞는 데이터베이스 설계와 코드 추가적인 폼개발이 필요
- 수정필요
