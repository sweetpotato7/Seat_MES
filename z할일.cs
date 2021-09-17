
/// ㅡㅡ메인메뉴
/// 구분선 추가하기
/// 
/// ㅡㅡ품목관리
/// 품번콤보박스 시도 -> 안되면 텍스트로
/// 품목이미지 배치 - 선택한 품목 이미지 출력 위치 정하기(좌측 or 하단)
/// 
/// ㅡㅡBOM
/// 위   - 등록구조, 모품목, 자품목
/// 아래 - 트리구조 - 선택 기준 정하기
///                   선택한 거에 대한 트리 구조를 어떻게 출력할지
/// 


/* BOM 트리 예제

// 최초 SearchNode를 호출합니다.
// 오버로드 함수는 이름이 같으나 파라미터 등으로 구분해서 사용합니다.

string strParentKey;

// 레코드에서 부모 Key를 가져옴
strParentKey = rdr.GetInt32(0).ToString();
//Nodes 콜렉션과 부모 Key를 가지고 함수 호출
TreeNode trParent = SearchNode(objTreeView.Nodes, strParantKey);

TreeNode trChild = new TreeNode();
// 레코드에서 자신의 Key를 가져옴 (예, "02")
trChild.Value = rdr.GetInt32(1).ToString();

// 레코드에서 자신의 Node 이름을 가져옴 (예, "종이접기")
trChild.Text = rdr.GetInt32(2).ToString();

// 부모노드에 추가
trParent.ChildNodes.Add(trChild);


//Tree 검색 - 재귀 호출 함수 (TreeView.Nodes,Key)
public TreeNode SearchNode(TreeNodeCollection objNodes, string strKey)
{
    // Nodes의 node를 가지고 찾을 때까지 반복합니다.
    foreach (TreeNode node in objNodes)
    {
        // 해당 Node를 찾을 경우 Node를 리턴합니다.
        if (node.Value == strKey) return node;

        // 없을 경우 하위 Nodes를 가지고 다시 SearchNode를 호출합니다.
        TreeNode findNode = SearchNode(node.ChildNodes, strKey);

        // 하위노드 검색 결과를 비교하여 Null이 아닐경우(찾은 경우) node를 리턴합니다.
        if (findNode != null)
            return findNode;
    }
    // 검색 결과 조건에 맞는 Node가 없을 경우 Null을 리턴합니다.
    return null;
}
*/