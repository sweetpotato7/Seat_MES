﻿
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
insert into TB_CODE_MST (PLANTCODE, MAJORCODE, MINORCODE, CODENAME, DISPLAYNO, USEFLAG, CREATE_DT) VALUES('D100', 'COMMON', 'Y', 'Y', '1', 'Y', GETDATE())
insert into TB_CODE_MST (PLANTCODE, MAJORCODE, MINORCODE, CODENAME, DISPLAYNO, USEFLAG, CREATE_DT) VALUES('D100', 'COMMON', 'N', 'N', '2', 'Y', GETDATE())
*/
#endregion