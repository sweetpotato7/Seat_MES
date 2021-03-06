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
![BOM](https://user-images.githubusercontent.com/91646481/142465280-ab5761ab-3fc8-4a26-a898-48b96e9bcfec.png)

- 작업지시
    - 수량을 입력하고 작업지시를 내리는 폼
    - 완제품(ALC) 수량을 기준으로 작업지시를 내리고 LH, RH로 나누어서 생산을 진행
![작업지시](https://user-images.githubusercontent.com/91646481/142465286-1e35e5c2-fcf3-4eda-a944-8ea11d7996e0.png)

- 조립공정
    - 트랙적재 공정을 완료한 FERT(LH,RH)들을 표시
    - 조립공정을 완료 한 품목을 공정실적으로 데이터 처리
    - 공정 진행중인 품목의 SPEC과 정보들을 조회
![조립공정](https://user-images.githubusercontent.com/91646481/142465481-daada132-8f4c-4d20-9610-e4e187144375.png)

- 공정실적
    - 모든 공정을 마친 품목을 FERT(LH,RH)단위로 조회
    - 아래의 그래프를 통해 당일 작업완료도와 일별 생산수량(ALC)을 조회
![공정실적](https://user-images.githubusercontent.com/91646481/142465273-6939ec87-c00a-4c55-973a-ddc1f99226ec.png)


✔ **프로젝트 소감 & 보완점**

- 코로나 단계 격상으로 불가피하게 비대면으로 프로젝트를 진행했습니다. 대면으로 프로젝트를 진행했다면 더 좋은 결과물을 만들 수 있지 않았을까 하는 아쉬움이 있었지만, GIT을 통해 프로젝트 협업을 진행하고 메신저를 통해 활발히 소통하며 진행하여 문제점들을 극복하려고 노력함으로써 비대면 협업이라는 새로운 환경을 경험해볼 수 있는 시간이었다고 생각합니다.
- 전체적으로 MES의 틀을 갖춘 프로그램을 개발할 수 있었습니다. 그러나 실무에서 사용 가능한 수준의 고도화가 필요
- 스캐너나 RF TAG를 연동한 구성이 필요
- 공정내에서 모니터 터치식으로 MES프로그램을 사용하는 것을 고려한 사용자인터페이스(UI)가 필요
