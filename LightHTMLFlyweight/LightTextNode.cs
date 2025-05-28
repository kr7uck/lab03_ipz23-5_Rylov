namespace LightHTMLComposer
{
    class LightTextNode : LightNode
    {
        private readonly string text;

        public LightTextNode(string text) => this.text = text;

        public override string InnerHTML => text;
        public override string OuterHTML => text;
    }

}