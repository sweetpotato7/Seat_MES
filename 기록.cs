
#region  ____0 9 월 1 8 일
/*
========== 전체그리드 ==========
등록할 때 내용 입력 시 콤보박스 뜨게끔
등록은 상단에 박스 만들어서 추가되게


=========== 메인메뉴 ===========


========== 품목관리 ==========
품번콤보박스 시도->안되면 텍스트로
품목이미지 배치 - 선택한 품목 이미지 출력 위치 정하기(좌측 or 하단)


========== 공통코드 ==========
주코드 + 주코드이름(열 추가하기, MAJORNAME)

왼쪽 주코드에 대한 오른쪽 부코드 보이기

========== BOM ==========
저장은 상단 패널 추가한 뒤 그리드에 재조회(모품목, 자품목,... )
검색조건 - 품번, 품명

========== 사양관리 ==========
추가,저장 구분
DB에는 코드로 그리드에는 변환된 값으로
ex)
DB - '000', 그리드 - '있음' 으로 표현
DB - '001', 그리드 - '없음' 으로 표현
DB - '002', 그리드 - '가죽' 으로 표현

========== 프로세스 순서 ==========
공통코드 : 개발팀
메뉴 등록, 그룹별 설정
           그룹 등록 - Admin, 생관, 생산, 품질...
               => 그룹 사용자 => 그룹별 프로그램(접근권한 관리-버튼 비활성화)
사용자 등록(Admin)
품번 등록
BOM 등록
사양(SPEC 등록)
공정 작업 순서

--상위 작업 완료 되야 가능

작업지시
생산 실적
품질 실적



*/
#endregion

#region ____0 9 월 1 8 일 SQL 추가사항
/*
insert into TB_CODE_MST (PLANTCODE, MAJORCODE, MINORCODE, CODENAME, DISPLAYNO, USEFLAG, CREATE_DT) VALUES('D100', 'USEFLAG', 'Y', 'Y', '1', 'Y', GETDATE())
insert into TB_CODE_MST (PLANTCODE, MAJORCODE, MINORCODE, CODENAME, DISPLAYNO, USEFLAG, CREATE_DT) VALUES('D100', 'USEFLAG', 'N', 'N', '2', 'Y', GETDATE())
*/
#endregion

#region ____0 9 월 2 5 일
/*
========== 공정순서 ==========
010 Track Loading

020 Covering 적재

030 Inspection


작업지시, 이미지, 사양정보, 작업순서

--작업순서
1. 공통코드로 잡기
공정코드 - 공정명
000 - JIG 도착 (기본)
010 - Lot 생성
020 - Track Scan
030 - Foam Pad Scan
040 - H/R Scan
050 - Covering Scan
060 - SAB Scan
070 - Complete (마무리)

순서  Working(작업방법)  Value(스캔값, LotNo,...)  결과("OK")
  1 /  JIG 도착       /                          /    OK
  2 /  LOT 생성       /      LOT값               /    OK
  3 /  Track Scan     / 트랙 바코드 값           /    OK
  4 /  Complete       /                          /    OK
 
--작업지시
 OrderNo    작업일자  순서  품번  계획수량  LH  RH
210930001 / 20210930 / 1 / A-ALC /   20   / 20 / 20
210930002 / 20210930 / 2 / B-ALC /   5    / 2 / 1
210930003 / 20210930 / 3 / A-ALC /   20   / O / O

LH/RH 는 작업 완료 수량


========== 생산계획 ==========
--Master - 차량에 대한 계획
작업지시NO   품번    계획량
 210930001 / A-ALC /   5
* 상태값 추가 (계획중, 투입중, 생산완료)
계획중 - 생산량 x면 계획중
투입중 - 
생산완료 - 계획량 = 생산량

--Detail - 석별 계획
 작업지시NO / 품번  /    / 순번 / LOT NO
 210930001  / A-ALC / LH /  1   / 210930001 + LH + 1
 210930001  / A-ALC / RH /  1   / 210930001RH1
 210930001  / A-ALC / LH /  2   / 210930001LH2
 210930001  / A-ALC / RH /  2   / 210930001RH2
     "      /   "   /  " /  20   /
     "      /   "   /  " /  20   /
// 기준정보 A-ALC, B-ALC, C-ALC.. 여러개 만들기


여담
USB Type - 포커스가 가 있어야 데이터가 들어옴
Serial Type - 다른작업을 해도 특정 위치에 데이터 넣을 수 있음
*/
#endregion